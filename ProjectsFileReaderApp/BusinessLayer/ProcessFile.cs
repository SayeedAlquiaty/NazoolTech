using ProjectsFileReaderApp.BusinessLayer.Interfaces;
using ProjectsFileReaderApp.Constants;
using ProjectsFileReaderApp.DTOs.Requests;
using ProjectsFileReaderApp.DTOs.Responses;
using ProjectsFileReaderApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ProjectsFileReaderApp.BusinessLayer
{   
    public class ProcessFile : IProcess
    {
        public GenerateObjectsResponse GenerateObjects(Request request)
        {
            var response = new GenerateObjectsResponse();
            var projectsFileRequest = request as ProjectsFileRequest;

            if (projectsFileRequest == null)
            {
                response.AddErrorMessage(string.Format("{0}: request type should be {1}", ErrorStatus.InvalidRequest, nameof(ProjectsFileRequest)));
                return response;
            }

            var header = new Dictionary<string, int>();
            var projectQuantities = new List<ProjectQuantity>();

            try
            {
                FileStream fileStream = new FileStream(projectsFileRequest.FilePath, FileMode.Open);
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine().TrimEnd();
                        if (line.Contains(Header.Project))
                        {
                            int index = 0;
                            foreach (var str in line.TrimEnd().Split('\t').ToList())
                            {
                                header.Add(str, index);
                                index += 1;
                            }
                        }
                        else if (line.StartsWith("#") || line.Length == 0)
                        {
                            //skip
                        }
                        else
                        {
                            var elements = line.TrimEnd().Split('\t').ToList();
                            if (!Complexity.Types.Contains(elements[header[Header.Complexity]]))
                            {
                                response.AddErrorMessage(string.Format("{0}: {1}", ErrorStatus.InvalidComplexity, elements[header[Header.Complexity]]));
                                return response;
                            }
                            var project = new Project
                            {
                                Id = elements[header[Header.Project]],
                                Description = elements[header[Header.Description]],
                                StartDate = DateTime.Parse(elements[header[Header.StartDate]]),
                                Category = elements[header[Header.Category]],
                                Responsible = elements[header[Header.Responsible]],
                                SavingsAmount = elements[header[Header.SavingsAmount]] == "NULL" ? "" : elements[header[Header.SavingsAmount]],
                                Currency = elements[header[Header.Currency]] == "NULL" ? "" : elements[header[Header.Currency]],
                                Complexity = elements[header[Header.Complexity]]
                            };
                            var projectSerialise = JsonSerializer.Serialize(project);
                            var entity = projectQuantities.Find(x => JsonSerializer.Serialize(x.Project) == projectSerialise);
                            if (entity != null)
                            {
                                entity.Count += 1;
                            }
                            else
                            {
                                projectQuantities.Add(new ProjectQuantity
                                {
                                    Project = project,
                                    Count = 1
                                });
                            }
                        }
                    }
                }
            }
            catch (ArgumentNullException nullEx)
            {
                response.AddErrorMessage(string.Format("{0}: {1}", ErrorStatus.InvalidArgument, nullEx.Message));
                return response;
            }
            catch (FormatException formatEx)
            {
                response.AddErrorMessage(string.Format("{0}: {1}", ErrorStatus.InvalidFormat, formatEx.Message));
                return response;
            }
            catch (FileNotFoundException fileNotFoundEx)
            {
                response.AddErrorMessage(string.Format("{0}: {1}", ErrorStatus.InvalidFilePath, fileNotFoundEx.Message));
                return response;
            }
            catch (Exception ex)
            {
                response.AddErrorMessage(string.Format("{0}: {1}",ErrorStatus.Exception, ex.Message));
                return response;
            }

            if (projectQuantities.Count > 0)
            {
                if (projectsFileRequest.IsSortByStartDate)
                {
                    projectQuantities = projectQuantities.OrderBy(x => x.Project.StartDate).ToList();
                }
                if(projectsFileRequest.ProjectId != null)
                {
                    response.Data = projectQuantities.Where(x => x.Project.Id == projectsFileRequest.ProjectId).ToList();
                }
                else
                {
                    response.Data = projectQuantities;
                }
                
            }

            return response;
        }
    }
}
