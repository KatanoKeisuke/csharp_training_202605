using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace katano.Infrastructures.Entities;
/// <summary>
/// 社員テーブル(employee)を扱うEntity Framework Coreのエンティティクラス
/// </summary>
[Table("employee")]
public class EmployeeEntity
{
    /// <summary>
    /// 社員Id(主キー)
    /// </summary>
    [Key]
    [Column("id")]
    public int EmpId { get; set; }
    [Column("name")]
    /// <summary>
    /// 社員名
    /// </summary>
    public string EmpName { get; set; } = string.Empty;
    /// <summary>
    /// 所属部署Id(外部キー)
    /// </summary>
    [Column("dept_id")]
    public int? DeptId { get; set; }

     [ForeignKey("DeptId")]
    public DepartmentEntity? Department { get; set; }

    public override string? ToString()
    {
        return $"社員Id:{EmpId},氏名:{EmpName},部署Id{DeptId}";
    }
}