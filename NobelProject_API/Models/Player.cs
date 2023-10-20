using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NobelProject_API.Models;

[Table("Player")]
public partial class Player
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("username")]
    public string? Username { get; set; }

    [Column("password_hash")]
    public string? PasswordHash { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("Player")]
    public virtual ICollection<GameMove> GameMoves { get; set; } = new List<GameMove>();

    [InverseProperty("Player")]
    public virtual ICollection<Game> Games { get; set; } = new List<Game>();

    [InverseProperty("Player")]
    public virtual PlayerStatistic? PlayerStatistic { get; set; }
}
