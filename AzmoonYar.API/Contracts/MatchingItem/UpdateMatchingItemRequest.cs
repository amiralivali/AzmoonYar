namespace AzmoonYar.API.Contracts.MatchingItem;

public record UpdateMatchingItemRequest(long Id,string LeftItemText, string RightItemText);