using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NobelProject_API.Models;

public partial class PlayerStatistic
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("total_games_played")]
    public long? TotalGamesPlayed { get; set; }

    [Column("wins")]
    public long? Wins { get; set; }

    [Column("losses")]
    public long? Losses { get; set; }

    [Column("ties")]
    public long? Ties { get; set; }
}
