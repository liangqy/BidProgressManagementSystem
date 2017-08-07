using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BidProgressManagementSystem.EntityFramework;
using BidProgressManagementSystem.Application;

namespace BidProgressManagementSystem.Web.Controllers
{
    public class ProjectController : BaseController
    {
        private readonly IProjectAppService _service;
        
        public ProjectController(IProjectAppService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Edit(Project project)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    Result = "Faild",
                    Message = GetModelStateError()
                });
            }
            if (project.Id == Guid.Empty)
                project.CreateTime = DateTime.Now;
            //dto.CreateUserId = 
            if (_service.InsertOrUpdate(project))
            {
                return Json(new { Result = "Success" });
            }
            return Json(new { Result = "Faild" });
        }

        public IActionResult GetAllList()
        {
            return Json(_service.GetAllList());
        }

        public IActionResult GetAllPageList(int startPage, int pageSize)
        {
            int rowCount = 0;
            var result = _service.GetAllPageList(startPage, pageSize, out rowCount);

            return Json(new
            {
                rowCount = rowCount,
                pageCount = Math.Ceiling(Convert.ToDecimal(rowCount) / pageSize),
                rows = result,
            });
        }

        public IActionResult DeleteMuti(string ids)
        {
            try
            {
                string[] idArray = ids.Split(',');
                List<Guid> delIds = new List<Guid>();
                foreach (string id in idArray)
                {
                    delIds.Add(Guid.Parse(id));
                }
                _service.DeleteBatch(delIds);
                return Json(new
                {
                    Result = "Success"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Result = "Faild",
                    Message = ex.Message
                });
            }
        }
        public IActionResult Delete(Guid id)
        {
            try
            {
                _service.Delete(id);
                return Json(new
                {
                    Result = "Success"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Result = "Faild",
                    Message = ex.Message
                });
            }
        }
        public IActionResult Get(Guid id)
        {
            var dto = _service.Get(id);
            return Json(dto);
        }

        public IActionResult GetWithUser(Guid projectId)
        {
            var project = _service.GetWithUser(projectId);
            return Json(project);
        }

        public IActionResult GetAllPageListByUser(Guid userId, int startPage, int pageSize, out int rowCount)
        {
            var projects = _service.GetAllPageListByUser(userId, startPage, pageSize, out rowCount);
            return Json(projects);
        }
    }
}