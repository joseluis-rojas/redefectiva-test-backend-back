﻿namespace Clean.Architecture.Web.Endpoints.PersonEndpoints;

public record DeletePersonRequest
{
  public const string Route = "/Persons/{PersonId:int}";
  public static string BuildRoute(int personId) => Route.Replace("{PersonId:int}", personId.ToString());

  public int PersonId { get; set; }
}
