namespace infrastructure;
public class AnalysisContext : DbContext
{
    public DbSet<Commit> Commits => Set<Commit>();

    public AnalysisContext() { }

    public AnalysisContext(DbContextOptions<AnalysisContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Commit>(e =>
        {
            e.Property(e => e.Author).IsRequired();
            e.Property(e => e.Timestamp).IsRequired();
            e.Property(e => e.Timestamp).HasConversion<string>();
            e.HasIndex(e => e.Timestamp).IsUnique();
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
            var configuration = new ConfigurationBuilder().AddUserSecrets<AnalysisContext>().Build();
            var connectionString = configuration.GetConnectionString("gitinsight");
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}