namespace infrastructure;
public class GitInsightContext : DbContext
{
    public DbSet<Analysis> Analyses => Set<Analysis>();

    public GitInsightContext() { }

    public GitInsightContext(DbContextOptions<GitInsightContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Analysis>(e =>
        {
            e.HasKey(e => e.RemoteUrl);
            e.HasIndex(e => e.RemoteUrl);
            e.HasMany(e => e.Authors).WithOne(a => a.Parent);
            e.Property(e => e.LastCommit).HasConversion<string>();
        });
    }

    /*
    password=$(uuidgen)
    database="gitinsight"
    connectionString="Host=localhost;Username=postgres;Password=$password;Database=$database"
    dotnet user-secrets init
    dotnet user-secrets set "ConnectionStrings:$database" "$connectionString"
    docker run --name $database -e POSTGRES_PASSWORD=$password -d -p 5432:5432 postgres 
    */
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<GitInsightContext>()
                .Build();
            var connectionString = configuration.GetConnectionString("gitinsight");
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}