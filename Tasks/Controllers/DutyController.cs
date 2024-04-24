using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tasks.API.Data.DTO;
using Tasks.API.Repositories.Interface;
using Tasks.Models.Domain;

namespace Tasks.API.Controllers
{
    [Route("api/Tasks")]
    [ApiController]
    [Authorize]
    public class DutyController : ControllerBase
    {
        private readonly IDutyRepository dutyRepository;
        public DutyController(IDutyRepository dutyRepository)
        {
            this.dutyRepository = dutyRepository;
        }

        
        [HttpPost]
        [Route("createDuty")]
        public async Task<IActionResult> CreateDuty(DutyRequestDTO request) //Crear Tarea
        {
            var duty = new Duty
            {
                title = request.title,
                detail = request.detail, 
                dueDate = request.dueDate,
                isCompleted = request.isCompleted,
                email = request.email,
            };
            await dutyRepository.CreateDuty(duty);
            return Ok(duty);
        }
        [HttpPost]
        [Route("userDuties")]
        public async Task<IActionResult> UserDuties(DutyRequestDTO request) //Consultar todas las tareas de un usuario
        {   
            return Ok(dutyRepository.UserDuties(request));
        }

        [HttpPut]
        [Route("updateDuty")]
        public async Task<IActionResult> UpdateDuty(Duty request)
        {
            DutyResponseDTO response = new DutyResponseDTO();
            response = await dutyRepository.UpdateDuty(request);

            if (response.statusOperation)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [Route("deleteDuty")]
        public async Task<IActionResult> DeleteDuty(Guid id) //Eliminar un registro de la tabla Duties
        {
            DutyResponseDTO response = new DutyResponseDTO();
            response = await dutyRepository.DeleteDuty(id);
            if (response.statusOperation)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
