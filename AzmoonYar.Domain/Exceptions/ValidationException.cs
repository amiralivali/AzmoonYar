using System.Net.Sockets;

namespace AzmoonYar.Domain.Exceptions;

public class ValidationException(string message) : Exception(message);