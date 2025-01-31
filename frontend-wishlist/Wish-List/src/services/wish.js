import axios from "axios";

axios.defaults.withCredentials = true; // Передача cookies при запросах

export const fetchWish = async (navigate) => {
  try {
    const response = await axios.get("http://localhost:5152/Wish/auth-user-wishes");

    // Проверка данных от API
    if (response.data && Array.isArray(response.data.wishes)) {
      console.log(response.data);
      return response.data.wishes;
    } else {
      console.error("Некорректный формат данных от API:", response.data);
      return [];
    }
  } catch (e) {
    if (e.code === "ERR_NETWORK" || e.message.includes("ERR_CONNECTION_REFUSED")) {
      console.error("Сервер недоступен (ERR_CONNECTION_REFUSED)");
      navigate("/auth/login"); // Перенаправление на страницу авторизации
    } else if (e.response && e.response.status === 401) {
      console.error("Ошибка авторизации, перенаправляем на страницу входа");
      navigate("/auth/login"); // Перенаправление на страницу авторизации
    } else {
      console.error("Произошла ошибка:", e.message);
    }
    return [];
  }
};


export const createWish = async (formDataToSend) => {
  try {
    const response = await axios.post("http://localhost:5152/wish", formDataToSend, {
      headers: {
        "Content-Type": "multipart/form-data",  // Если отправляете файлы
      },
    });
    return response.data;
  } catch (error) {
    console.error("Ошибка при создании желания:", error.response?.data || error.message);
    throw error;
  }
};



export const editWish = async (wishId, editData) => {
  try {
    const response = await axios.put(
      `http://localhost:5152/Wish/update-wish?wishId=${wishId}`, // Замените на ваш URL
      editData,
      {
        headers: {
          'Content-Type': 'application/json',
        },
        withCredentials: true, // Если сессия или куки используются
      }
    );
    return response.data;
  } catch (error) {
    console.error('Error editing wish:', error);
    throw error;
  }
};



export const deleteWish = async (wishId) => {
  const url = `http://localhost:5152/Wish/delete-wish?wishId=${wishId}`;
  try {
    const response = await axios.delete(url, {
      data: { wishId }, // Если сервер ожидает тело запроса
      headers: {
        "Content-Type": "application/json", // Указываем заголовок
      },
    });
    return response.data;
  } catch (error) {
    console.error("Ошибка при удалении желания:", error);
    throw error;
  }
};

