using ApiCrudCoreDoctores.Data;
using ApiCrudCoreDoctores.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudCoreDoctores.Repositories
{
    public class RepositoryDoctores
    {
        private DoctoresContext context;

        public RepositoryDoctores(DoctoresContext context)
        {
            this.context = context;
        }

        public async Task<List<Doctor>> GetDoctoresAsync()
        {
            return await this.context.Doctores.ToListAsync();
        }



        public async Task<Doctor> FindDoctorAsync(int idDoctor)
        {
            return await this.context.Doctores.FirstOrDefaultAsync(s => s.IdDoctor == idDoctor);
        }

        public async Task InsertDoctorAsync(Doctor doc)
        {
            this.context.Doctores.Add(doc);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateDoctorAsync(Doctor doc)
        {
            Doctor doctor = await this.FindDoctorAsync(doc.IdDoctor);
            doctor.IdHospital = doc.IdHospital;
            doctor.Salario = doc.Salario;
            doctor.Apellido = doc.Apellido;
            doctor.Especialidad = doc.Especialidad;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(int id)
        {
            Doctor doc = await this.FindDoctorAsync(id);
            this.context.Doctores.Remove(doc);
            await this.context.SaveChangesAsync();
        }


    }
}
