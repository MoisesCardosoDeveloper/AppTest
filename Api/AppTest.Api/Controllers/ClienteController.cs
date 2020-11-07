using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppTest.Domain.Entities;
using AppTest.Domain.Interfaces.Service;
using AppTest.IoC;
using AppTest.Repository.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace AppTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        protected readonly IClienteService<AppTestContext> _service;
        protected readonly IStringLocalizer _localizer = ServiceLocator.Resolve<IStringLocalizer>();

        public ClienteController(IClienteService<AppTestContext> service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<IActionResult> Get()
        {
            try
            {
                return Task.FromResult<IActionResult>(Ok(_service.GetAll()));
            }
            catch (Exception ex)
            {
                return Task.FromResult<IActionResult>(StatusCode(500, new { ErrorCode = 500, Message = ex.Message }));
            }
        }


        [HttpGet("{id}")]
        public virtual Task<IActionResult> Get(int id)
        {
            try
            {
                return Task.FromResult<IActionResult>(Ok(_service.Get(id)));
            }
            catch (Exception ex)
            {
                return Task.FromResult<IActionResult>(StatusCode(500, new { ErrorCode = 500, Message = ex.Message }));
            }
        }


        [HttpPost]
        public virtual Task<IActionResult> Post([FromBody] Cliente model)
        {
            try
            {
                var result = _service.Save(model);
                _service.Commit();
                return Task.FromResult<IActionResult>(Ok(result));
            }
            catch (Exception ex)
            {
                return Task.FromResult<IActionResult>(StatusCode(500,new { ErrorCode = 500, Message = ex.Message }));
            }
        }


        [HttpPut("{id}")]
        public virtual Task<IActionResult> Put(long id, [FromBody] Cliente cliente)
        {
            try
            {
                var result = _service.Update(cliente);

                //_service.Delete(10);
                //_service.AtualizarSaldo();
                //_service.Bloquear();

                _service.Commit();
                return Task.FromResult<IActionResult>(Ok(result));
            }
            catch (Exception ex)
            {
                return Task.FromResult<IActionResult>(StatusCode(500, new { ErrorCode = 500, Message = ex.Message }));
            }
        }


        [HttpDelete("{id}")]
        public virtual Task<IActionResult> Delete(int id)
        {
            try
            {
                _service.Delete(id);
                _service.Commit();
                return Task.FromResult<IActionResult>(Ok());
            }
            catch (Exception ex)
            {
                return Task.FromResult<IActionResult>(StatusCode(500, new { ErrorCode = 500, Message = ex.Message }));
            }
        }
    }
}