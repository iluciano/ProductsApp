using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {

        public DataSet TrazerTodosProdutos()
        {

            SqlConnection conexao = conexaoBD.RetornarConexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conexao;
            cmd.CommandText = @"SELECT codprod, nomeprod, imagemprod, precoprod FROM casamento.PRODUTOS ORDER BY codprod";
            cmd.Connection.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);

            return ds;
        }

        public List<Product> TrazerProdutos()
        {
            Product produtos = new Product();
            DataSet ds = TrazerTodosProdutos();
            List<Product> ListaProdutos = new List<Product>();
            Product objProduto;

            if(ds.Tables.Count > 0){
                if(ds.Tables[0].Rows.Count > 0){
                    foreach(DataRow dr in ds.Tables[0].Rows){
                        objProduto = new Product();
                        objProduto.codprod = Convert.ToInt32(dr["codprod"].ToString());
                        objProduto.nomeprod = dr["nomeprod"].ToString();
                        objProduto.imagemprod = dr["imagemprod"].ToString();
                        objProduto.precoprod = Convert.ToDecimal(dr["precoprod"].ToString());

                        ListaProdutos.Add(objProduto);
                    }
                }
            }
            return ListaProdutos;
        }

        Product[] products = new Product[] 
        { 
            new Product { Id = 1, Name = "Tomate", Category = "Horti", Price = 1.0M }, 
            new Product { Id = 2, Name = "Cabeça de Batata", Category = "Brinquedos", Price = 39.75M }, 
            new Product { Id = 3, Name = "Placa de vídeo", Category = "Hardware", Price = 160.99M } 
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
