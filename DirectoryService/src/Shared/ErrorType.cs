namespace Shared;

public enum ErrorType
{
    /// <summary>
    /// Неизвестная ошибка
    /// </summary>
    NONE,

    /// <summary>
    /// Ошибка валидации
    /// </summary>
    VALIDATION,

    /// <summary>
    /// Запись не найдена
    /// </summary>
    NOT_FOUND,

    /// <summary>
    /// Ошибка сервера
    /// </summary>
    FAILURE,

    /// <summary>
    /// Конфликт
    /// </summary>
    CONFLICT,
}