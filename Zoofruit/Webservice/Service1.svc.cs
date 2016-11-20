using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Biblioteca.basica;
using Biblioteca.negocio;

namespace Webservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    public class Service1 : IService1
    {


        RNUsuario rnusuario;
        RNTipoUsuario rntipousuario;
        RNMedicamento rnmedicamento;
        RNAlimento rnalimento;
        RNAnimal rnanimal;
        RNTipoAnimal rntipoanimal;
        RNFichaAlimento rnfichaalimento;
        RNFichaExecucaoAlimento rnfichaexecucaoalimento;

        private Service1()
        {
            rnusuario = new RNUsuario();
            rntipousuario = new RNTipoUsuario();
            rnmedicamento = new RNMedicamento();
            rnalimento = new RNAlimento();
            rnanimal = new RNAnimal();
            rntipoanimal = new RNTipoAnimal();
            rnfichaalimento = new RNFichaAlimento();
            rnfichaexecucaoalimento = new RNFichaExecucaoAlimento();
        }


        /* ------------------- Usuario -------------------------------------- */
        public void InserirUsuario(Usuario u)
        {
            rnusuario.Adicionar(u);
        }

        public void AlterarUsuario(Usuario u)
        {
            rnusuario.Alterar(u);
        }

        public void ExcluirUsuario(Usuario u)
        {
            rnusuario.Excluir(u);
        }

        public List<TipoUsuario> ListarTipoUsuario(TipoUsuario tu)
        {
            return rntipousuario.NListarTipoUsuario(tu);
        }

        public List<Usuario> ListarUsuario(Usuario u)
        {
            return rnusuario.NListarUsuario(u);
        }

        /* ------------------- Alimento -------------------------------------- */
        public List<Alimento> ListarAlimento(Alimento a)
        {
            return rnalimento.NListarAlimento(a);
        }

        public void InserirAlimento(Alimento a)
        {
            rnalimento.Adicionar(a);
        }

        public void AlterarAlimento(Alimento a)
        {
            rnalimento.Alterar(a);
        }

        public void ExcluirAlimento(Alimento a)
        {
            rnalimento.Excluir(a);
        }

        /* ------------------- Medicamento -------------------------------------- */
        public List<Medicamento> ListarMedicamento(Medicamento m)
        {
            return rnmedicamento.NListarMedicamento(m);
        }

        public void InserirMedicamento(Medicamento m)
        {
            rnmedicamento.Adicionar(m);
        }

        public void AlterarMedicamento(Medicamento m)
        {
            rnmedicamento.Alterar(m);
        }

        public void ExcluirMedicamento(Medicamento m)
        {
            rnmedicamento.Excluir(m);
        }

        /* ------------------- Animal -------------------------------------- */
        public List<TipoAnimal> ListarTipoAnimal(TipoAnimal ta)
        {
            return rntipoanimal.NListarTipoAnimal(ta);
        }
        public List<Animal> ListarAnimal(Animal a)
        {
            return rnanimal.NListarAnimal(a);
        }

        public void InserirAnimal(Animal a)
        {
            rnanimal.Adicionar(a);
        }

        public void AlterarAnimal(Animal a)
        {
            rnanimal.Alterar(a);
        }

        public void ExcluirAnimal(Animal a)
        {
            rnanimal.Excluir(a);
        }

        /* ------------------- Ficha Alimento -------------------------------------- */
        public List<FichaAlimento> ListarFichaAlimento(FichaAlimento fa)
        {
            return rnfichaalimento.NListarFichaAlimento(fa);
        }

        public void InserirFichaAlimento(FichaAlimento fa)
        {
            rnfichaalimento.Adicionar(fa);
        }

        public void AlterarFichaAlimento(FichaAlimento fa)
        {
            rnfichaalimento.Alterar(fa);
        }

        public void ExcluirFichaAlimento(FichaAlimento fa)
        {
            rnfichaalimento.Excluir(fa);
        }

        /* ------------------- Ficha Execução Alimento -------------------------------------- */
        public List<Alimento> PesquisarAlimentoFichaExecucaoAlimento(int codigo)
        {
            return rnfichaexecucaoalimento.NListarFichaExecucaoAlimentoAlimento(codigo);
        }
    }
}
