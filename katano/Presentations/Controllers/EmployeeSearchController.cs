using Microsoft.AspNetCore.Mvc;
using katano.Applications.Services;
using katano.Presentations.ViewModels;

namespace katano.Presentations.Controllers;
/// <summary>
/// リスト4-3 
/// Razor構文の利用
/// </summary>
[Route("EmployeeSearch")]
public class EmployeeSearchController : Controller
{
    /// <summary>
    /// ロガー
    /// </summary>
    private readonly ILogger<EmployeeSearchController> _logger;
    /// <summary>
    /// 部署登録サービスインターフェイス
    /// </summary>
    private readonly IEmployeeRegisterService _employeeRegisterService;
    /// <summary>
    /// 従業員登録ViewModelをDepartmentに変換するアダプター
    /// </summary>
    private readonly EmployeeSearchViewModelAdapter _adapter;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logger">ロガー</param>
    /// <param name="employeeSearchService">部署登録サービスインターフェイス</param>
    /// <param name="employeeRegisterViewModelAdapter">部署登録ViewModelをDepartmentに変換するアダプター</param>
    /// <param name="empDataStore">TempDataを通じて一時的にViewModelを保存・復元するためのクラス</param>
    public EmployeeSearchController(
        ILogger<EmployeeSearchController> logger,
        IEmployeeRegisterService employeeRegisterService,
        EmployeeSearchViewModelAdapter employeeSearchViewModelAdapter)
    {
        _logger = logger;
        _employeeRegisterService = employeeRegisterService;
        _adapter = employeeSearchViewModelAdapter;
    }
    /// <summary>
    /// ViewModel SampleFormのListをRazor View Show.cshtmlに渡す
    /// </summary>
    /// <returns></returns>
    [HttpGet("Search")]
    public ActionResult Search()
    {
        var employees = _employeeRegisterService.GetEmployees();
        List<EmployeeSearchViewModel> employeeSearchViewModels = new List<EmployeeSearchViewModel>();
        foreach (var emp in employees)
        {
            //Adapterを使いDepartmentからDepartmentSearchViewModelに変換する 
            var viewModel = _adapter.Convert(emp);
            //departmentSearchViewModelsにviewModelをAddする
            employeeSearchViewModels.Add(viewModel);
        }
        //return view で引数にviewmodelのリストを渡す
        return View(employeeSearchViewModels);

    }
}