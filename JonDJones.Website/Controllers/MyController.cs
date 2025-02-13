﻿using JonDJones.Website.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace JonDJones.Website.Controller;

public class MyControllerController : RenderController
{
    private ITransient transient1;
    private ITransient transient2;
    private IScoped scoped1;
    private IScoped scoped2;
    private ISingleton singleton;

    public MyControllerController(
            ILogger<MyControllerController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            ITransient _transient1,
            ITransient _transient2,
            IScoped _scoped1,
            IScoped _scoped2,
            ISingleton _singleton)
        : base(logger, compositeViewEngine, umbracoContextAccessor)
    {
        transient1 = _transient1;
        transient2 = _transient2;
        scoped1 = _scoped1;
        scoped2 = _scoped2;
        singleton = _singleton;
    }

    public override IActionResult Index()
    {
        // Dependency injection video example
        var transient1Id = transient1.Id;
        var transient2Id = transient2.Id;
        var scoped1Id = scoped1.Id;
        var scoped2Id = scoped2.Id;
        var singletonId = singleton.Id;

        return View("~/Views/MyController.cshtml", new MyViewModel());
    }
}


public class MyViewModel
{
    public string MyData { get; set; }
}