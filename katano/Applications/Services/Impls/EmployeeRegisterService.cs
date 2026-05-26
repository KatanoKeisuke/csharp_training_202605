using katano.Applications.Repositories;
using katano.Applications.Domains;
using katano.Exceptions;
using katano.Infrastructures.Context;
namespace katano.Applications.Services.Impls;
/// <summary>
/// 従業員登録サービスインターフェイスの実装
/// </summary>
public class EmployeeRegisterService : IEmployeeRegisterService
{

    /// <summary>
    /// アプリケーション用DbContext
    /// </summary>
    private readonly AppDbContext _context;
    /// <summary>
    /// ドメインオブジェクト:従業員のCRUD操作インターフェイス
    /// </summary>
    private readonly IEmployeeRepository _employeeRepository;
    /// <summary>
    /// ドメインオブジェクト:部署のCRUD操作インターフェイス
    /// </summary>
    private readonly IDepartmentRepository _departmentRepository;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context">アプリケーション用DbContext</param>
    /// <param name="employeeRepository">従業員のCRUD操作インターフェイス</param>
    /// <param name="departmentRepository">部署のCRUD操作インターフェイス</param>
    public EmployeeRegisterService(
        AppDbContext context,
        IEmployeeRepository employeeRepository,
        IDepartmentRepository departmentRepository)
    {
        _context = context;
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
    }

    /// <summary>
    /// 指定された部署Idの部署を取得する
    /// </summary>
    /// <param name="id">部署Id</param>
    /// <returns></returns>
    public Department GetById(int id)
    {
        var result = _departmentRepository.FindById(id)!;
        if (result == null)
        {
            throw new NotFoundException($"部署Id{id}に該当する部署は存在しません");
        }
        return result;
    }

    /// <summary>
    /// すべての部署を取得する
    /// </summary>
    /// <returns></returns>
    public List<Department> GetDepartments()
    {
        return _departmentRepository.FindAll();
    }

        /// <summary>
    /// 指定された社員Idの部署を取得する
    /// </summary>
    /// <param name="empid">部署Id</param>
    /// <returns></returns>
    public Employee GetByEmpId(int empid)
    {
        var result = _employeeRepository.FindById(empid)!;
        if (result == null)
        {
            throw new NotFoundException($"部署Id{empid}に該当する部署は存在しません");
        }
        return result;
    }

    /// <summary>
    /// すべての社員を取得する
    /// </summary>
    /// <returns></returns>
    public List<Employee> GetEmployees()
    {
        return _employeeRepository.FindAll();
    }

    /// <summary>
    /// 新しい従業員を登録する
    /// </summary>
    /// <param name="employee"></param>
    public void Register(Employee employee)
    {
        try
        {
            // トランザクションの開始
            _context.Database.BeginTransaction();
            // 従業員の登録
            _employeeRepository.Create(employee);
            // トランザクションのコミット
            _context.Database.CommitTransaction();   
        }
        catch
        {
            // トランザクションのロールバック
            _context.Database.RollbackTransaction();
            throw;
        }
    }
}