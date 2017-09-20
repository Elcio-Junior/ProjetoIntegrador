using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Servico
{
    public interface IGenericService<T> where T : IModel<int>
    {
        /// <summary>
        /// Retorno de uma entidade simples através do Id
        /// </summary>
        /// <param name="id">Id a ser buscado</param>
        /// <returns>Entidade encontrada pelo Id ou vazio</returns>
        T Get(int id);

        /// <summary>
        /// Retorno de uma entidade simples através de um filtro
        /// </summary>
        /// <param name="filter">Filtro em Linq para ser aplicado</param>
        /// <returns>Entidade encontrada pelo Filtro ou vazio</returns>
        T Get(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Retorna todas as entidades
        /// </summary>
        /// <returns>Query da entidade</returns>
        IQueryable<T> Load();

        /// <summary>
        /// Retorno das entidades através de um filtro
        /// </summary>
        /// <param name="filter">Filtro em Linq para ser aplicado</param>
        /// <returns>Retorno das entidades encontradas pelo filtro</returns>
        IQueryable<T> Load(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Deleta uma entidade pelo Id
        /// </summary>
        /// <param name="id">Id da entidade a ser deletada</param>
        void Delete(int id);

        /// <summary>
        /// Atualiza uma entidade
        /// </summary>
        /// <param name="id">Id da entidade a ser atualizada</param>
        /// <param name="entity">Entidade a ser atualizada</param>
        void Update(int id, T entity);

        /// <summary>
        /// Salva uma entidade
        /// </summary>
        /// <param name="entity">Entidade a ser salva</param>
        void Save(T entity);

        /// <summary>
        /// Get total count results
        /// </summary>
        /// <returns></returns>
        int GetCount();

        /// <summary>
        /// Get all results with filter
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>return filter</returns>
        int GetCount(Expression<Func<T, bool>> filter);
    }
}