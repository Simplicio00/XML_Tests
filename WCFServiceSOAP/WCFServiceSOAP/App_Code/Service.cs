using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;

/// <summary>
/// Descrição resumida de Service
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
[System.Web.Script.Services.ScriptService]
public class Service : WebService
{

	public Service()
	{

		//Remova os comentários da linha a seguir se usar componentes designados 
		//InitializeComponent(); 
	}

	private const string connection = "Data Source=LUCASSOLIVEIRA\\SQLEXPRESS; Initial Catalog=ExperimentoENTERPRISE; Integrated Security=True";



	/// <summary>
	/// Faz a busca pelos funcionários
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	[WebMethod]
	public Funcionario GetFuncionario(int id)
	{
		using (var cn = new SqlConnection(connection))
		{
			try
			{
				return cn.QuerySingle<Funcionario>("select * from FUNCIONARIO_ENTERPRISE where id =" + id.ToString());
			}
			catch (Exception ex)
			{

				return new Funcionario() { message = "Ocorreu um erro: " + ex.Message };
			}
			
		}

	}


	/// <summary>
	/// Faz a busca pelo setor
	/// </summary>
	/// <param name="id">Id do setor</param>
	/// <returns></returns>
	[WebMethod]
	public Setor GetSetor(int id)
	{
		using (var cn = new SqlConnection(connection))
		{
			try
			{
				return cn.QuerySingle<Setor>("select * from SETOR_ENTERPRISE where id =" + id.ToString());
			}
			catch (Exception ex)
			{

				return new Setor() { message = "Ocorreu um erro: " + ex.Message };
			}

		}

	}



	/// <summary>
	/// Faz o cadastro de um novo funcionário
	/// </summary>
	/// <param name="nome"></param>
	/// <returns></returns>
	[WebMethod]
	public Message NovoFuncionario(string nome)
	{
		using (var cn = new SqlConnection(connection))
		{
			try
			{
				cn.Execute("insert into FUNCIONARIO_ENTERPRISE(nome)values('" + nome+"')");

				//XmlBuilder xml = new XmlBuilder();

				return new Message() { message = "Cadastrado com sucesso" };
			}
			catch (Exception ex)
			{

				return new Funcionario() { message = "Ocorreu um erro: " + ex.Message };
			}

		}
	}


	/// <summary>
	/// Faz o cadastro de um novo setor
	/// </summary>
	/// <param name="staffNumber"></param>
	/// <returns></returns>
	[WebMethod]
	public Message NovoSetor(int staffNumber)
	{
		using (var cn = new SqlConnection(connection))
		{
			try
			{
				cn.Execute("insert into SETOR_ENTERPRISE(staff)values(" + staffNumber + ")");

				return new Message() { message = "Cadastrado com sucesso" };
			}
			catch (Exception ex)
			{
				return new Message() { message = "Ocorreu um erro: " };
			}

		}
	}

}


public class Message
{
	public string message { get; set; }
}

public class Setor : Message
{
	private bool defaultstatus = true;
	public int Id { get; set; }
	public int Staff { get; set; }
	public bool Status { get { return defaultstatus; } set { defaultstatus = value; } }
}

public class Funcionario : Message
{
	public int Id { get; set; }
	public string Nome { get; set; }
}

