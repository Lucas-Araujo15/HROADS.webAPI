using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webAPI.Interfaces
{
    interface IClassHabRepository
    {
        List<ClassHab> Listar();

        ClassHab BuscarPorId(int idClassHab);

        void Cadastrar(ClassHab novaClassHab);

        void Atualizar(int idClassHab, ClassHab ClassHabAtualizada);

        void Deletar(int idClassHab);
    }
}
