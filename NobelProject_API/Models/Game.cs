using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NobelProject_API.Models;

/// <summary>
/// games table
/// </summary>
public partial class Game
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("start_time")]
    public DateTime StartTime { get; set; }

    [Column("end_time")]
    public DateTime? EndTime { get; set; }

    [Column("result", TypeName = "character varying")]
    public string? Result { get; set; }
}
