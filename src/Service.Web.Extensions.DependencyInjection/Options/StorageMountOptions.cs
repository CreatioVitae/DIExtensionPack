using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Service.Extensions.DependencyInjection.Options;
public class StorageMountOptions {
    public IEnumerable<StorageMountOption> Options { get; init; } = null!;
}

public class StorageMountOption {
    public string Label { get; init; } = null!;

    public string Path { get; init; } = null!;
}
