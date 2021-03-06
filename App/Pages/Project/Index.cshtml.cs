﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Database.Models;
using App.Database.Repositories.Project;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Project
{
    public class IndexModel : PageModel
    {
        private readonly IProjectRepository _projectTbl;
        public IndexModel(IProjectRepository projectTbl)
        {
            _projectTbl = projectTbl ?? throw new ArgumentNullException(nameof(projectTbl));
        }

        public IEnumerable<ProjectTbl> Projects { get; set; }
        public async Task OnGet()
        {
            Projects = await _projectTbl.Get(orderBy: x => x.OrderByDescending(a => a.DateModified));
        }
    }
}