using EmployeePlatform.Entities;
using EmployeePlatform.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace EmployeePlatform.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IIdentityHelper _identityHelper;

        public EmployeeController(IIdentityHelper identityHelper)
        {
            _identityHelper = identityHelper;
        }
        public async Task<IActionResult> Index()
        {
            int PageSize = int.Parse(Environment.GetEnvironmentVariable("PAGE_SIZE_INITIAL"));
            var query = @"query getEmployeesPaginate($pageSize: Int!, $page: Int!){
                                    employees(pageSize:$pageSize){
                                      totalPages
                                      totalRecords
    									results(page:$page, pageSize:$pageSize) {
                                        id,
                                        identificationNumber,
                                        identificationType {
                                          name
                                        },
                                        firstName,
                                        lastName,
                                        subarea {
                                          name,
                                          area {
                                            name
                                          }
                                        }
                                      }
                                  }
                                }";

            var variable = new
            {
                pageSize = PageSize,
                page = 1
            };
            EmployePaginationDTO result = await new GraphqlConexionEntityHelper<EmployePaginationDTO>(_identityHelper).GraphqlConexionEntity(query, variable, false);
            if (result != null)
            {
                result.Token = _identityHelper.GetCurrentToken();
                return View(result);
            }
            else
            {
                return View(result != null ? result : new EmployePaginationDTO
                {
                    TotalPages = 0,
                    TotalRecords = 0
                });

            }
        }
        public async Task<IActionResult> Register()
        {
            var query = @"query{
                              areas{
                                id,
                                name
                              },
                              identificationTypes{
                                id,
                                name
                              }
                            }";
            string data = await new GraphqlConexionStringHelper(_identityHelper).GraphqlConexionString(query, true);
            EmployeGeneralDTO dataList = JsonConvert.DeserializeObject<EmployeGeneralDTO>(data);
            ViewBag.IdentificationTypes = dataList.Data.IdentificationTypes;
            ViewBag.Areas = dataList.Data.Areas;
            return View(new EmployeeDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(EmployeeDTO model)
        {
            var queryList = @"query{
                              areas{
                                id,
                                name
                              },
                              identificationTypes{
                                id,
                                name
                              }
                            }";

            string data = await new GraphqlConexionStringHelper(_identityHelper).GraphqlConexionString(queryList, true);
            EmployeGeneralDTO dataList = JsonConvert.DeserializeObject<EmployeGeneralDTO>(data);
            ViewBag.IdentificationTypes = dataList.Data.IdentificationTypes;
            ViewBag.Areas = dataList.Data.Areas;

            if (ModelState.IsValid)
            {
                var query = @"mutation createEmployee(
                                  $identificationNumber: String!,
                                  $firstName: String!,
	                                $subareaId: Int!, 
                                  $lastName:  String!,
                                  $identificationTypeId: Int!
                                ){
                                  createEmployee(input:{
                                    identificationNumber: $identificationNumber,
                                    firstName: $firstName,
                                    lastName: $lastName,
                                    subareaId: $subareaId,
                                    identificationTypeId: $identificationTypeId
                                  }){
                                    identificationType{
                                      id,
                                      name
                                    },
                                    lastName,
                                    firstName,
                                    identificationNumber,
                                    subarea{
                                      id,
                                      name,
                                      area{
                                        id,
                                        name
                                      }
                                    }
                                  }
}
                            ";

                var variable = new
                {
                    identificationNumber = model.IdentificationNumber,
                    firstName = model.FirstName,
                    lastName = model.LastName,
                    subareaId = model.SubareaId,
                    identificationTypeId = model.IdentificationTypeId
                };
                EmployeeDTO employee = await new GraphqlConexionEntityHelper<EmployeeDTO>(_identityHelper).GraphqlConexionEntity(query, variable, true);

                if (employee == null)
                {
                    employee.Token = _identityHelper.GetCurrentToken();
                    TempData["Message"] = "Empleado no fue registrado";
                    TempData["Type"] = "Error";
                    return View(model);
                }

                TempData["Message"] = "Empleado registrado correctamente";
                TempData["Type"] = "Ok";
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                TempData["Message"] = "Datos incorrectos";
                TempData["Type"] = "Error";
                return View(model);
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            int PageSize = int.Parse(Environment.GetEnvironmentVariable("PAGE_SIZE_INITIAL"));

            var query2 = @"query{
                              areas{
                                id,
                                name
                              },
                              identificationTypes{
                                id,
                                name
                              }
                            }";
            string data = await new GraphqlConexionStringHelper(_identityHelper).GraphqlConexionString(query2, true);
            EmployeGeneralDTO dataList = JsonConvert.DeserializeObject<EmployeGeneralDTO>(data);
            ViewBag.IdentificationTypes = dataList.Data.IdentificationTypes;
            ViewBag.Areas = dataList.Data.Areas;

            var query = @"query getEmployee($id: Int!){
                              employee(id:$id){
                                identificationType{
                                  id,
                                  name
                                },
                                lastName,
                                firstName,
                                identificationNumber,
                                subarea{
                                  id,
                                  name,
                                  area{
                                    id,
                                    name
                                  }
                                }
                              }
                            }";

            var variable = new
            {
                id = id
            };
            EmployeeDTO result = await new GraphqlConexionEntityHelper<EmployeeDTO>(_identityHelper).GraphqlConexionEntity(query, variable, false);
            if (result == null)
            {
                TempData["Message"] = "Empleado no encontrado";
                TempData["Type"] = "Error";
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeDTO model)
        {
            var query2 = @"query{
                              areas{
                                id,
                                name
                              },
                              identificationTypes{
                                id,
                                name
                              }
                            }";
            string data = await new GraphqlConexionStringHelper(_identityHelper).GraphqlConexionString(query2, true);
            EmployeGeneralDTO dataList = JsonConvert.DeserializeObject<EmployeGeneralDTO>(data);
            ViewBag.IdentificationTypes = dataList.Data.IdentificationTypes;
            ViewBag.Areas = dataList.Data.Areas;

            if (ModelState.IsValid)
            {
                var query = @"mutation updateEmployee(
                                  $id: Int!
                                  $identificationNumber: String!,
                                  $firstName: String!,
	                                $subareaId: Int!, 
                                  $lastName:  String!,
                                  $identificationTypeId: Int!
                                ){
                                  updateEmployee(input:{
                                    id: $id,
                                    identificationNumber: $identificationNumber,
                                    firstName: $firstName,
                                    lastName: $lastName,
                                    subareaId: $subareaId,
                                    identificationTypeId: $identificationTypeId
                                  }){
                                    identificationType{
                                      id,
                                      name
                                    },
                                    lastName,
                                    firstName,
                                    identificationNumber,
                                    subarea{
                                      id,
                                      name,
                                      area{
                                        id,
                                        name
                                      }
                                    }
                                  }
                                }";

                var variable = new
                {
                    id = model.Id,
                    identificationNumber = model.IdentificationNumber,
                    firstName = model.FirstName,
                    lastName = model.LastName,
                    subareaId = model.SubareaId,
                    identificationTypeId = model.IdentificationTypeId
                };
                EmployeeDTO employee = await new GraphqlConexionEntityHelper<EmployeeDTO>(_identityHelper).GraphqlConexionEntity(query, variable, true);

                if (employee == null)
                {
                    TempData["Message"] = "Empleado no fue registrado";
                    TempData["Type"] = "Error";
                    return View(model);
                }

                TempData["Message"] = "Empleado modificado correctamente";
                TempData["Type"] = "Ok";
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                TempData["Message"] = "Datos incorrectos";
                TempData["Type"] = "Error";
                return View(model);
            }
        }
    }
}