using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NobelProject_API.Models;

public partial class GameMove
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("game_id")]
    public long GameId { get; set; }

    [Column("user_move", TypeName = "character varying")]
    public string UserMove { get; set; } = null!;

    [Column("computer_move", TypeName = "character varying")]
    public string ComputerMove { get; set; } = null!;

    [Column("result", TypeName = "character varying")]
    public string Result { get; set; } = null!;

    [Column("player_id")]
    public long? PlayerId { get; set; }

    [ForeignKey("PlayerId")]
    [InverseProperty("GameMoves")]
    public virtual Player? Player { get; set; }
}
