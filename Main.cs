using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace OdataText;

[Owned]
public class Properties
{
    public string Property1 {get;set;}
}

public class Main
{
    [Key]
    public long Id {get;set;}
    public Properties Properties {get;set;}
}