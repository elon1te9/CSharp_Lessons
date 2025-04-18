using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Ex
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer mainTimer; // Главный таймер 
        private DateTime? alarmTime; // Время срабатывания будильника                                                                                                                                                                                                                                                                          
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
            if (int.TryParse(TimerHoursTextBox.Text, out int hours) &&
                int.TryParse(TimerMinutesTextBox.Text, out int minutes) &&
                int.TryParse(TimerSecondsTextBox.Text, out int seconds))
            {
                if (hours < 0 || minutes < 0 || minutes > 59 || seconds < 0 || seconds > 59)
                {
                    MessageBox.Show("Пожалуйста, введите корректные неотрицательные значения (Минуты/Секунды: 0-59).", "Ошибка ввода");
                    return;
                }

                timerDuration = new TimeSpan(hours, minutes, seconds);

                if (timerDuration <= TimeSpan.Zero)
                {
                    MessageBox.Show("Пожалуйста, установите длительность таймера больше нуля.", "Ошибка ввода");
                    return;
                }

                timerTimeLeft = timerDuration;
                isTimerRunning = true;
                UpdateTimerDisplay();

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
            isTimerRunning = false;
            timerTimeLeft = TimeSpan.Zero;
            UpdateTimerDisplay();

            SetTimerControlsEnabled(true);
            StopTimerButton.IsEnabled = false;
        }

        private void UpdateTimerDisplay()
        {
            TimerCountdownTextBlock.Text = $"{(int)timerTimeLeft.TotalHours:D2}:{timerTimeLeft.Minutes:D2}:{timerTimeLeft.Seconds:D2}";
        }

        private void SetTimerControlsEnabled(bool isEnabled)
        {
            TimerHoursTextBox.IsEnabled = isEnabled;
            TimerMinutesTextBox.IsEnabled = isEnabled;
            TimerSecondsTextBox.IsEnabled = isEnabled;
            StartTimerButton.IsEnabled = isEnabled;
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            if (isAlarmSet && alarmTime.HasValue)
            {
                TimeSpan timeLeft = alarmTime.Value - now;

                if (timeLeft.TotalSeconds <= 0)
                {
                    isAlarmSet = false;
                    MessageBox.Show("Вставай!", "Будильник!");
                    alarmTime = null;
                    SetAlarmControlsEnabled(true);
                    CancelAlarmButton.IsEnabled = false;
                }

                UpdateAlarmStatus();
            }

            if (isTimerRunning)
            {
                timerTimeLeft = timerTimeLeft.Subtract(mainTimer.Interval);

                if (timerTimeLeft <= TimeSpan.Zero)
                {
                    timerTimeLeft = TimeSpan.Zero;
                    isTimerRunning = false;
                    UpdateTimerDisplay();
                    MessageBox.Show("Время вышло!", "Таймер");

                    SetTimerControlsEnabled(true);
                    StopTimerButton.IsEnabled = false;
                }
                else
                {
                    UpdateTimerDisplay();
                }
            }
        }

        private void EnableDatePickerCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AlarmDatePicker.IsEnabled = true;
        }

        private void EnableDatePickerCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            AlarmDatePicker.IsEnabled = false;
        }
    }
}