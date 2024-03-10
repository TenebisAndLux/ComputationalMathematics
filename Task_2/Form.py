import aim
import сomputational_mathematics as cm
from PyQt5.QtWidgets import QComboBox, QPushButton, QLineEdit, QFormLayout
import sys
import numpy as np
from PyQt5.QtWidgets import QApplication, QWidget, QVBoxLayout, QLabel
from PyQt5.QtGui import QIcon
from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg as FigureCanvas
from matplotlib.figure import Figure


class Form(QWidget):
    def __init__(self):
        super().__init__()
        self.initUI()

    def initUI(self):
        self.setWindowTitle('Lab2')
        self.setWindowIcon(QIcon('icon.png'))
        self.setGeometry(100, 100, 800, 940)

        main_layout = QVBoxLayout()

        # Группа "Уравнение"
        equation_html = '<span style="color:rgb(87, 46, 120); font-size:28px;">Уравнение:</span>'
        equation_html += '<br>'
        equation_html += '<span style="font-size:28px;">y = x<sup>3</sup> - 10 * x + 2</span>'

        # Создаем QLabel с использованием HTML разметки
        label_equation = QLabel(self)
        label_equation.setText(equation_html)
        label_equation.setWordWrap(True)  # Переносим текст если он не помещается в окне

        # Добавляем QLabel в вашу группу и на главный слой
        group_equation = QVBoxLayout()
        group_equation.addWidget(label_equation)
        main_layout.addLayout(group_equation)

        # Группа "Параметры"
        self.group_parameters = QFormLayout()

        label_name = QLabel('Параметры:', self)
        label_name.setStyleSheet("color: rgb(87, 46, 120); font-size: 28px")
        self.group_parameters.addWidget(label_name)

        self.label_a = QLabel('a:', self)
        self.label_a.setStyleSheet("color: rgb(87, 46, 120); font-size: 20px")
        self.line_edit_a = QLineEdit(self)
        self.line_edit_a.setText('-10000.0')

        self.label_b = QLabel('b:', self)
        self.label_b.setStyleSheet("color: rgb(87, 46, 120); font-size: 20px")
        self.line_edit_b = QLineEdit(self)
        self.line_edit_b.setText('10000.0')

        self.group_parameters.addRow(label_name)
        self.group_parameters.addRow(self.label_a, self.line_edit_a)
        self.group_parameters.addRow(self.label_b, self.line_edit_b)
        main_layout.addLayout(self.group_parameters)

        # Группа "Действия"
        self.group_actions = QVBoxLayout()

        label_actions = QLabel('Действия:', self)
        label_actions.setStyleSheet("color: rgb(87, 46, 120); font-size: 28px")

        self.button_find_solution = QPushButton('Решить', self)
        self.button_find_solution.clicked.connect(self.findSolution)

        self.combo_box_solutions = QComboBox(self)
        self.combo_box_solutions.addItems(
            ['Метод половинного деления', 'Метод хорд', 'Метод Ньютона', 'Модифицированный метод',
             'Комбинированный метод', 'Итерационный метод'])

        group_parameters = QFormLayout()
        group_parameters.addRow(label_actions)
        group_parameters.addRow(self.button_find_solution, self.combo_box_solutions)

        self.group_actions.addLayout(group_parameters)

        self.label_result = QLabel('Результат:', self)
        self.label_result.setStyleSheet("color: rgb(87, 46, 120); font-size: 20px")
        self.group_actions.addWidget(self.label_result)

        self.line_edit_result = QLineEdit(self)
        self.group_actions.addWidget(self.line_edit_result)

        self.line_edit_roots = QLineEdit(self)
        self.group_actions.addWidget(self.line_edit_roots)

        self.line_edit_section = QLineEdit(self)
        self.group_actions.addWidget(self.line_edit_section)

        self.line_edit_result.setText(f"Решения: ")
        self.line_edit_roots.setText(f"Найдено: z интервалов")
        self.line_edit_section.setText(f"Отрезок (a, b)")

        main_layout.addLayout(self.group_actions)

        self.setLayout(main_layout)

        # Добавление виджета для графика
        self.canvas = FigureCanvas(Figure())
        main_layout.addWidget(self.canvas)

        self.setLayout(main_layout)
        self.plotGraph()

    def findSolution(self):
        method = self.combo_box_solutions.currentText()

        a = float(self.line_edit_a.text())
        b = float(self.line_edit_b.text())

        x_range = np.array(np.arange(a, b, step=0.1), dtype=np.float64)
        y_range = aim.f(x_range)

        solution_range = []
        for i in range(len(x_range) - 1):
            if y_range[i] * y_range[i + 1] < 0:
                solution_range.append((x_range[i], x_range[i + 1]))

        strResult = 'Решения: '
        strSection = 'Отрезки: '

        self.line_edit_roots.setText(f"Найдено: {len(solution_range)} интервала")

        for a, b in solution_range:
            if method == 'Метод половинного деления':
                strResult += ('[' + str(cm.half_div_method(aim.f, aim.f_d, a, b)) + '] ')
                strSection += (f" ({a}, {b}) ")
            elif method == 'Метод хорд':
                strResult += ('[' + str(cm.chord_method(aim.f, aim.f_d, aim.f_dd, a, b)) + '] ')
                strSection += (f" ({a}, {b}) ")
            elif method == 'Метод Ньютона':
                strResult += ('[' + str(cm.newtons_method(aim.f, aim.f_d, a, b)) + '] ')
                strSection += (f" ({a}, {b}) ")
            elif method == 'Модифицированный метод':
                strResult += ('[' + str(cm.modified_newtons_method(aim.f, aim.f_d, a, b)) + '] ')
                strSection += (f" ({a}, {b}) ")
            elif method == 'Комбинированный метод':
                strResult += ('[' + str(cm.combined_method(aim.f, aim.f_d, a, b)) + '] ')
                strSection += (f" ({a}, {b}) ")
            elif method == 'Итерационный метод':
                strResult += ('[' + str(cm.iterative_method(aim.f, aim.f_d, a, b)) + '] ')
                strSection += (f" ({a}, {b}) ")

        self.line_edit_section.setText(strSection)
        self.line_edit_result.setText(strResult)
        solution_range.clear()

    def plotGraph(self):
        x = np.linspace(-10, 10, 400)
        y = x ** 3 - 10 * x + 2
        ax = self.canvas.figure.subplots()
        ax.plot(x, y, label='$x^3 - 10x + 2$', color='b')

        # Добавляем оси axis
        ax.spines['left'].set_position(('data', 0))
        ax.spines['bottom'].set_position(('data', 0))
        ax.spines['right'].set_color('none')
        ax.spines['top'].set_color('none')
        ax.yaxis.set_ticks_position('left')
        ax.xaxis.set_ticks_position('bottom')

        # Добавляем точки на оси x и их значения
        x_intercepts = x[np.where(np.diff(np.signbit(y)))[0]]
        for x_intercept in x_intercepts:
            ax.plot(x_intercept, 0, 'ro')  # добавляем красную точку
            ax.annotate(f'x={x_intercept:.2f}', (x_intercept, 0.5), color='r')  # добавляем значение x

        # Ограничиваем график по оси y до 15
        ax.set_ylim(-15, 15)

        ax.set_title('График уравнения')
        ax.set_xlabel('X')
        ax.set_ylabel('Y')
        ax.grid(True)
        ax.legend()

        self.canvas.draw()

if __name__ == '__main__':
    app = QApplication(sys.argv)
    form = Form()
    form.show()
    sys.exit(app.exec_())
