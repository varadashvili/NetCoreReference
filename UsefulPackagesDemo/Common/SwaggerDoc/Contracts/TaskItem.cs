using System.ComponentModel.DataAnnotations;

namespace UsefulPackagesDemo.Common.SwaggerDoc.Contracts;

/// <summary>
/// task item info
/// </summary>
public class TaskItem
{
    /// <summary>
    /// task identifier
    /// </summary>
    /// <example>15</example>
    [Required]
    public int Id { get; set; }

    /// <summary>
    /// task title
    /// </summary>
    /// <example>new task</example>
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

}
