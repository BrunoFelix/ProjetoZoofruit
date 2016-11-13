using Biblioteca.basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Webservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        #region Usuario
        [OperationContract]
        List<TipoUsuario> ListarTipoUsuario(TipoUsuario tu);

        [OperationContract]
        List<Usuario> ListarUsuario(Usuario u);

        [OperationContract]
        void InserirUsuario(Usuario u);

        [OperationContract]
        void AlterarUsuario(Usuario u);

        [OperationContract]
        void ExcluirUsuario(Usuario u);
        #endregion

        #region Alimento
        [OperationContract]
        List<Alimento> ListarAlimento(Alimento a);

        [OperationContract]
        void InserirAlimento(Alimento a);

        [OperationContract]
        void AlterarAlimento(Alimento a);

        [OperationContract]
        void ExcluirAlimento(Alimento a);
        #endregion

        #region Medicamento
        [OperationContract]
        List<Medicamento> ListarMedicamento(Medicamento m);

        [OperationContract]
        void InserirMedicamento(Medicamento m);

        [OperationContract]
        void AlterarMedicamento(Medicamento m);

        [OperationContract]
        void ExcluirMedicamento(Medicamento m);
        #endregion

        #region Animal

        [OperationContract]
        List<TipoAnimal> ListarTipoAnimal(TipoAnimal ta);

        [OperationContract]
        List<Animal> ListarAnimal(Animal a);

        [OperationContract]
        void InserirAnimal(Animal a);

        [OperationContract]
        void AlterarAnimal(Animal a);

        [OperationContract]
        void ExcluirAnimal(Animal a);
        #endregion

        #region Ficha Alimento
        [OperationContract]
        List<FichaAlimento> ListarFichaAlimento(FichaAlimento fa);

        [OperationContract]
        void InserirFichaAlimento(FichaAlimento fa);

        [OperationContract]
        void AlterarFichaAlimento(FichaAlimento fa);

        [OperationContract]
        void ExcluirFichaAlimento(FichaAlimento fa);
        #endregion
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
