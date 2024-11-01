using CadastroCliente.Context;
using CadastroCliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.WebEncoders.Testing;

namespace CadastroCliente.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ClienteController : Controller
    {
        private readonly ClienteContext _contextClient;

        public ClienteController(ClienteContext contextClient)
        {
            _contextClient = contextClient;
        }

        [HttpPost("Create")]
        public IActionResult Create(Cliente client)
        {
            
            _contextClient.Add(client);
            _contextClient.SaveChanges();
            return Ok(client);
        }

        [HttpGet("Read")]
        public IActionResult Read(int id)
        {
            var infoClient = _contextClient.Clientes.Find(id);
            if (infoClient == null)
                return NotFound();
            return Ok(infoClient);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, string nome, string cpf, string email, string phone)
        {
            //pega todas as propriedades da nossa model, mas está pesquisando apenas o id. 
           var infoClient = _contextClient.Clientes.Find(id);
            if (infoClient == null)
                return NotFound();

            //atribuindo os valores dos parametros dentro da variável(infoClient) que está com os valores que já estão salvos no DB
            infoClient.UserName = nome;
            infoClient.UserCPF = cpf;
            infoClient.UserEmail = email;
            infoClient.UserPhone = phone;

            _contextClient.Clientes.Update(infoClient);
            _contextClient.SaveChanges();
            return Ok("Updated data");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id) {
                
            var infoClient = _contextClient.Clientes.Find(id);
            if(infoClient == null) 
                return NotFound();

            _contextClient.Remove(infoClient);
            _contextClient.SaveChanges();
            return Ok();
        }

        [HttpGet("GetAllClient")]
        public IActionResult GetAllClients()
        {
           var baseClient = _contextClient.Clientes.ToList();
            return Ok(baseClient);
        }

    }
}
