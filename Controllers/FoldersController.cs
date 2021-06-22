using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartGoalApp.Controllers.Resources;
using SmartGoalApp.Models;
using SmartGoalApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGoalApp.Controllers
{
    public class FoldersController : Controller
    {
        protected IFolderRepository folderRepository;
        protected readonly IMapper mapper;
        protected readonly IUnitOfWork unitOfWork;
        public FoldersController(IMapper mapper, IFolderRepository folderRepository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.folderRepository = folderRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("/api/folders/email/{userEmail}")]
        public async Task<IActionResult> GetFolders(string userEmail)
        {
            var folders = await folderRepository.GetFolders(userEmail);
            if (folders == null || folders.Count == 0)
                return NotFound();
            IList<FolderResource> folderResourceResults = new List<FolderResource>();
            foreach(var f in folders)
            {
                folderResourceResults.Add(mapper.Map<Folder, FolderResource>(f));
            }
            return Ok(folderResourceResults);
        }

        [HttpGet]
        [Route("/api/folders/id/{id}")]
        public async Task<IActionResult> GetFolders(int id)
        {
            var folder = await folderRepository.GetFolder(id);
            if (folder == null)
                return NotFound();
            var folderResourse = mapper.Map<Folder, FolderResource>(folder);
            return Ok(folderResourse);
        }

        [HttpPost]
        [Route("/api/folders")]
        public async Task<IActionResult> CreateFolder([FromBody] SaveFolderResource folderResource)
        {
            //Validate Model Binding issue happen
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var folder = mapper.Map<SaveFolderResource, Folder>(folderResource);

            folderRepository.AddFolder(folder);
            await unitOfWork.Complete();

            await folderRepository.GetFolder(folder.Id);

            var result = mapper.Map<Folder, FolderResource>(folder);
            return Ok(result);
        }
    }
}
