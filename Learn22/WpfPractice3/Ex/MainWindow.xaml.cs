using System;
using System.Windows;
using System.Windows.Threading;

namespace Ex
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer mainTimer; // Главный таймер для обновления интерфейса и проверок
        private DateTime? alarmTime; // Время срабатывания будильника (nullable, т.к. может быть не установлен)
        private bool isAlarmSet = false; // Флаг, установлен ли будильник

        private TimeSpan timerDuration; // Общая длительность таймера
        private TimeSpan timerTimeLeft; // Оставшееся время таймера
        private bool isTimerRunning = false; // Флаг, запущен ли таймер

        public MainWindow()
        {
            InitializeComponent();
            InitializeMainTimer();
            AlarmDatePicker.SelectedDate = DateTime.Today;
        }

        private void InitializeMainTimer()
        {
            mainTimer = new DispatcherTimer();
            mainTimer.Interval = TimeSpan.FromSeconds(1);
            mainTimer.Tick += MainTimer_Tick;
            mainTimer.Start();
        }


        private void SetAlarmButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(AlarmHourTextBox.Text, out int hour) &&
                int.TryParse(AlarmMinuteTextBox.Text, out int minute))
            {
                if (hour < 0 || hour > 23 || minute < 0 || minute > 59)
                {
                    MessageBox.Show("Пожалуйста, введите корректное время (Часы: 0-23, Минуты: 0-59).", "Ошибка ввода");
                    return;
                }

                DateTime now = DateTime.Now;
                DateTime today = now.Date;
                DateTime selectedTime = today.AddHours(hour).AddMinutes(minute); 

                DateTime targetDateTime;

                if (EnableDatePickerCheckBox.IsChecked == true && AlarmDatePicker.SelectedDate.HasValue)
                {
                    DateTime selectedDate = AlarmDatePicker.SelectedDate.Value.Date;

                    if (selectedDate < today)
                    {
                        MessageBox.Show("Нельзя установить будильник на прошедшую дату.", "Ошибка даты");
                        return;
                    }

                    if (selectedDate == today && selectedTime < now)
                    {
                        MessageBox.Show("Нельзя установить будильник на прошедшее время сегодня. Будет установлено на завтра.", "Предупреждение");
                        targetDateTime = selectedTime.AddDays(1);
                    }

                    else
                    {
                        targetDateTime = selectedDate.AddHours(hour).AddMinutes(minute);
                    }
                }
                else 
                {
                    if (selectedTime <= now)
                    {
                        targetDateTime = selectedTime.AddDays(1);
                        MessageBox.Show($"Выбранное время ({hour:D2}:{minute:D2}) сегодня уже прошло. Будильник установлен на завтра.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        targetDateTime = selectedTime; 
                    }
                }

                alarmTime = targetDateTime;
                isAlarmSet = true;
                UpdateAlarmStatus();

                SetAlarmControlsEnabled(false);
                CancelAlarmButton.IsEnabled = true;

            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения для часов и минут.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CancelAlarmButton_Click(object sender, RoutedEventArgs e)
        {
            isAlarmSet = false;
            alarmTime = null;
            UpdateAlarmStatus(); 

            SetAlarmControlsEnabled(true);
            CancelAlarmButton.IsEnabled = false;
        }

        private void UpdateAlarmStatus()
        {
            if (isAlarmSet && alarmTime.HasValue)
            {
                DateTime now = DateTime.Now;
                TimeSpan timeLeft = alarmTime.Value - now;

                if (timeLeft.TotalSeconds > 0)
                {
                    AlarmStatusTextBlock.Text = $"Будильник сработает: {alarmTime.Value:dd.MM.yyyy HH:mm}";
                    AlarmCountdownTextBlock.Text = $"Осталось: {timeLeft.Days} д {timeLeft.Hours} ч {timeLeft.Minutes} м {timeLeft.Seconds} с";
                }
                else
                {
                    AlarmStatusTextBlock.Text = "Будильник сработал!";
                    AlarmCountdownTextBlock.Text = "";
                }
            }
            else
            {
                AlarmStatusTextBlock.Text = "Будильник не установлен";
                AlarmCountdownTextBlock.Text = "";
            }
        }

        private void SetAlarmControlsEnabled(bool isEnabled)
        {
            AlarmHourTextBox.IsEnabled = isEnabled;
            AlarmMinuteTextBox.IsEnabled = isEnabled;
            EnableDatePickerCheckBox.IsEnabled = isEnabled;
            if (isEnabled) 
            {
                AlarmDatePicker.IsEnabled = EnableDatePickerCheckBox.IsChecked == true;
            }
            else
            {
                AlarmDatePicker.IsEnabled = false;
            }
            SetAlarmButton.IsEnabled = isEnabled;
        }


        private void StartTimerButton_Click(object sender, RoutedEventArgs e)
        {
            // Парсинг времени из TextBox'ов
            if (int.TryParse(TimerHoursTextBox.Text, out int hours) &&
                int.TryParse(TimerMinutesTextBox.Text, out int minutes) &&
                int.TryParse(TimerSecondsTextBox.Text, out int seconds))
            {
                // Валидация введенного времени
                if (hours < 0 || minutes < 0 || minutes > 59 || seconds < 0 || seconds > 59)
                {
                    MessageBox.Show("Пожалуйста, введите корректные неотрицательные значения (Минуты/Секунды: 0-59).", "Ошибка ввода");
                    return;
                }

                timerDuration = new TimeSpan(hours, minutes, seconds);

                // Проверяем, что длительность больше нуля
                if (timerDuration <= TimeSpan.Zero)
                {
                    MessageBox.Show("Пожалуйста, установите длительность таймера больше нуля.", "Ошибка ввода");
                    return;
                }

                timerTimeLeft = timerDuration; // Устанавливаем начальное оставшееся время
                isTimerRunning = true; // Устанавливаем флаг, что таймер запущен
                UpdateTimerDisplay(); // Обновляем отображение таймера

                // Блокируем контролы и кнопку старта, разблокируем кнопку стоп
                SetTimerControlsEnabled(false);
                StopTimerButton.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения для таймера.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void StopTimerButton_Click(object sender, RoutedEventArgs e)
        {
            isTimerRunning = false; // Останавливаем таймер
            timerTimeLeft = TimeSpan.Zero; // Сбрасываем время
            UpdateTimerDisplay(); // Обновляем отображение

            // Разблокируем контролы и кнопку старта, блокируем кнопку стоп
            SetTimerControlsEnabled(true);
            StopTimerButton.IsEnabled = false;
        }

        // Обновление отображения таймера
        private void UpdateTimerDisplay()
        {
            // Форматируем оставшееся время в формат ЧЧ:ММ:СС
            TimerCountdownTextBlock.Text = $"{(int)timerTimeLeft.TotalHours:D2}:{timerTimeLeft.Minutes:D2}:{timerTimeLeft.Seconds:D2}";
        }

        // Включение/отключение контролов таймера
        private void SetTimerControlsEnabled(bool isEnabled)
        {
            TimerHoursTextBox.IsEnabled = isEnabled;
            TimerMinutesTextBox.IsEnabled = isEnabled;
            TimerSecondsTextBox.IsEnabled = isEnabled;
            StartTimerButton.IsEnabled = isEnabled;
        }

        // --- Общий обработчик тика таймера ---

        // Этот метод вызывается каждую секунду (согласно mainTimer.Interval)
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            // --- Проверка Будильника ---
            if (isAlarmSet && alarmTime.HasValue)
            {
                TimeSpan timeLeft = alarmTime.Value - now;

                // Если время будильника наступило или уже прошло
                if (timeLeft.TotalSeconds <= 0)
                {
                    isAlarmSet = false; // Сбрасываем будильник
                    MessageBox.Show("Вставай!", "Будильник!", MessageBoxButton.OK, MessageBoxImage.Information);
                    alarmTime = null; // Очищаем время будильника
                    // Разблокируем контролы и кнопку установки, блокируем кнопку отмены
                    SetAlarmControlsEnabled(true);
                    CancelAlarmButton.IsEnabled = false;
                }
                // Обновляем статус и оставшееся время будильника каждую секунду
                UpdateAlarmStatus();
            }

            // --- Обновление Таймера ---
            if (isTimerRunning)
            {
                // Уменьшаем оставшееся время на интервал таймера (1 секунда)
                timerTimeLeft = timerTimeLeft.Subtract(mainTimer.Interval);

                // Если время вышло
                if (timerTimeLeft <= TimeSpan.Zero)
                {
                    timerTimeLeft = TimeSpan.Zero; // Убедимся, что не отображается отрицательное время
                    isTimerRunning = false; // Останавливаем таймер
                    UpdateTimerDisplay(); // Обновляем отображение (покажет 00:00:00)
                    MessageBox.Show("Время вышло!", "Таймер", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Разблокируем контролы и кнопку старта, блокируем кнопку стоп
                    SetTimerControlsEnabled(true);
                    StopTimerButton.IsEnabled = false;
                }
                else
                {
                    // Обновляем отображение оставшегося времени таймера каждую секунду
                    UpdateTimerDisplay();
                }
            }
        }
    }
}