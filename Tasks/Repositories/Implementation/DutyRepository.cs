using Microsoft.EntityFrameworkCore;
using Tasks.API.Data.DTO;
using Tasks.API.Repositories.Interface;
using Tasks.Data;
using Tasks.Models.Domain;

namespace Tasks.API.Repositories.Implementation
{
    public class DutyRepository : IDutyRepository
    {
        private readonly ApplicationDbContext dbContext;
        public DutyRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Duty> CreateDuty(Duty duty)
        {
            await dbContext.Duties.AddAsync(duty);
            await dbContext.SaveChangesAsync();
            return duty;
        }

        public async Task<List<Duty>> UserDuties(DutyRequestDTO duty)
        {
            List<Duty> duties = new List<Duty>();
            var tareitas = await dbContext.Duties.Where(p => p.email == duty.email).ToListAsync();
            foreach(var element in tareitas)
            {
                duties.Add(element);
            }
            return duties;
        }

        public async Task<DutyResponseDTO> UpdateDuty(Duty request)
        {
            DutyResponseDTO response = new DutyResponseDTO(request.title, "No se encontró la tarea", "Actualizar", false);

            var task = await dbContext.Duties.FindAsync(request.id);
            if (task != null)
            {

                task.title = request.title;
                task.detail = request.detail;
                task.dueDate = request.dueDate;
                task.isCompleted = request.isCompleted;
                await dbContext.SaveChangesAsync();
                response.message = "Actualizado con éxito";
                response.statusOperation = true;
                return response;
            }
            else
            {
                return response;
            }
        }

        public async Task<DutyResponseDTO> DeleteDuty(Duty request)
        {
            DutyResponseDTO response = new DutyResponseDTO(request.title,"No se encontró la tarea","Eliminar",false);

            var task = await dbContext.Duties.FindAsync(request.id);
            if (task != null)
            {
                dbContext.Duties.Remove(request);
                await dbContext.SaveChangesAsync();
                response.message = "Se eliminó con éxito";
                response.statusOperation = true;
                return response;
            }
            else
            {
                return response;
            }
        }

    }
}
