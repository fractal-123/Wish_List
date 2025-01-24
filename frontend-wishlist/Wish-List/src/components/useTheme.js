import { useState, useEffect } from "react";

/**
 * Custom hook for managing light/dark theme.
 * @returns {{ isDarkMode: boolean, toggleTheme: () => void }}
 */
const useTheme = () => {
    const [isDarkMode, setIsDarkMode] = useState(() => {
        // Читаем начальное значение из localStorage или по умолчанию false
        const savedTheme = localStorage.getItem("theme");
        return savedTheme === "dark";
    });

    useEffect(() => {
        // Переключаем классы для body
        if (isDarkMode) {
            document.documentElement.classList.add("dark");
            localStorage.setItem("theme", "dark"); // Сохраняем тему в localStorage
        } else {
            document.documentElement.classList.remove("dark");
            localStorage.setItem("theme", "light");
        }
    }, [isDarkMode]);

    const toggleTheme = () => {
        setIsDarkMode((prev) => !prev);
    };

    return { isDarkMode, toggleTheme };
};

export default useTheme;