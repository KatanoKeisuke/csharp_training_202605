using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using katano.Applications.Domains;
namespace katano.Presentations.ViewModels;
/// <summary>
/// 部署登録ViewModelクラス
/// </summary>
public class EmployeeSearchViewModel
{
    [Display(Name = "社員番号")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    public int? EmpId { get; set; } = 0;
    /// <summary>
    /// 氏名
    /// </summary>
    [Display(Name = "氏名")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    public string? Name { get; set; } = string.Empty;
    /// <summary>
    /// 所属部署
    /// </summary>
    [Display(Name = "所属部署")]
    [Required(ErrorMessage = "{0}は選択必須です。")]
    public int? DeptId { get; set; } = 0;

    /// <summary>
    /// 選択された部署名
    /// </summary>
    [Display(Name = "部署名")]
    public string? DeptName { get; set; } = string.Empty;

}