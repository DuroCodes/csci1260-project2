using Microsoft.JSInterop;
using Project2.Models;

namespace Project2.Services;

using System.Text.Json;

public class NotesService(IJSRuntime jsRuntime, CharacterService characterService, ItemService itemService)
{
    private const string StorageKey = "notes";

    public async Task<List<Note>> GetNotesAsync()
    {
        var json = await jsRuntime.InvokeAsync<string>("localStorage.getItem", StorageKey);

        return string.IsNullOrEmpty(json)
            ? []
            : JsonSerializer.Deserialize<List<Note>>(json) ?? [];
    }

    private async Task SaveNotesAsync(List<Note> notes)
    {
        var json = JsonSerializer.Serialize(notes);
        await jsRuntime.InvokeVoidAsync("localStorage.setItem", StorageKey, json);
    }

    public async Task AddNoteAsync(Note note)
    {
        var notes = await GetNotesAsync();
        var newId = notes.Count > 0 ? notes.Max(n => n.Id) + 1 : 1;
        notes.Add(note with { Id = newId });
        await SaveNotesAsync(notes);
    }

    public async Task DeleteNoteAsync(int id)
    {
        var notes = await GetNotesAsync();
        notes = notes.Where(n => n.Id != id).ToList();
        await SaveNotesAsync(notes);
    }

    public async Task UpdateNoteAsync(Note note)
    {
        var notes = await GetNotesAsync();
        var index = notes.FindIndex(n => n.Id == note.Id);
        if (index == -1) return;

        notes[index] = note;
        await SaveNotesAsync(notes);
    }
}