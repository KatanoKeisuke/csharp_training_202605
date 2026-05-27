using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using katano.Applications.Domains;
namespace katano.Presentations.ViewModels;
/// <summary>
/// 部署登録ViewModelクラス
/// </summary>
public class DepartmentRegisterViewModel
{
    /// <summary>
    /// 部署名
    /// </summary>
    [Display(Name = "部署名")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    [MaxLength(20)]
    public string? Name { get; set; } = string.Empty;
    

    public override string ToString()
    {
        return $"Name={Name}";
    }
}