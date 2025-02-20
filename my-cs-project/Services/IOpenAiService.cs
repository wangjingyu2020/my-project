namespace my_cs_project.Services;

public interface IOpenAiService
{
    public Task<string> talkWithGPT(string prompt);
}