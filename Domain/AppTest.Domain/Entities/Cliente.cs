using System;
using System.Collections.Generic;

namespace AppTest.Domain.Entities
{
    public class Cliente : EntityBase
    {
        #region Propriedades
        public int ClienteId { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        #endregion

        #region Construtores
        private Cliente()
        {
            this.Ativo = true;
        }
        public Cliente(string razaoSocial, string cpfCnpj) : this()
        {
            this.AtualizarRazaoSocial(razaoSocial);
            this.AtualizarCNPJ(cpfCnpj);
        }

        #endregion

        #region Metodos
        public void AtualizarRazaoSocial(string razaoSocial)
        {
            ///todo
            this.RazaoSocial = razaoSocial;
        }
        public void AtualizarCNPJ(string cnpj)
        {
            this.CNPJ = cnpj;
        }
        public void Ativar() => this.Ativo = true;
        public void Inativar() => this.Ativo = false;
        #endregion
    }
}
