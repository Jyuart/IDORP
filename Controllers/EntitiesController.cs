using System;
using IdorpDemo.BL;
using Microsoft.AspNetCore.Mvc;

namespace IdorpDemo.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class EntitiesController : ControllerBase
{
    private readonly Entity _entity = new(new Id<Guid>(Guid.NewGuid()), "Entity");

    [HttpGet]
    public Entity Get() => _entity;

    [HttpPost]
    public Guid Post([FromBody] CreateEntity request) => request.Id.Value;
}

public class CreateEntity
{
    public Id<Guid> Id { get; set; }
    public string Name { get; set; }
}
}