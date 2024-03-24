import sys
import numpy as np
from PyQt5.QtGui import QIcon

import algorithm as alg
from PyQt5.QtWidgets import QApplication, QWidget, QVBoxLayout, QPushButton, QLabel, QLineEdit, QTextEdit
import solution


class MainWindow(QWidget):
    def __init__(self):
        super().__init__()

        self.setWindowIcon(QIcon('icon.png'))
        self.layout = QVBoxLayout()

        self.matrix_a_label = QLabel("Матрица A:")
        self.layout.addWidget(self.matrix_a_label)
        self.matrix_a_input = QTextEdit()
        self.layout.addWidget(self.matrix_a_input)

        self.matrix_b_label = QLabel("Матрица B:")
        self.layout.addWidget(self.matrix_b_label)
        self.matrix_b_input = QTextEdit()
        self.layout.addWidget(self.matrix_b_input)

        self.error_input = QLineEdit()
        self.layout.addWidget(self.error_input)

        self.cond_button = QPushButton("Вычислить число обусловленности")
        self.cond_button.clicked.connect(self.calculate_condition)
        self.layout.addWidget(self.cond_button)

        self.solve_button = QPushButton("Решить")
        self.solve_button.clicked.connect(self.solve_system)
        self.layout.addWidget(self.solve_button)

        self.det_button = QPushButton("Найти определитель")
        self.det_button.clicked.connect(self.calculate_determinant)
        self.layout.addWidget(self.det_button)

        self.result_output = QTextEdit()
        self.layout.addWidget(self.result_output)

        self.setLayout(self.layout)
        self.setWindowTitle('SLAE Solver')
        self.setGeometry(300, 300, 300, 300)

    def calculate_condition(self):
        matrix_a_text = self.matrix_a_input.toPlainText()
        matrix_a_text = matrix_a_text.replace('[', '').replace(']', '').replace(',', '')
        rows_a = matrix_a_text.split('\n')

        A = np.matrix([[float(x) for x in row.split()] for row in rows_a])

        cond = alg.cond(A)
        self.result_output.setPlainText(f"Число обусловленности: {cond}")

    def solve_system(self):
        matrix_a_text = self.matrix_a_input.toPlainText()
        matrix_a_text = matrix_a_text.replace('[', '').replace(']', '').replace(',', '')
        rows_a = matrix_a_text.split('\n')

        matrix_b_text = self.matrix_b_input.toPlainText()
        matrix_b_text = matrix_b_text.replace('[', '').replace(']', '').replace(',', '')
        rows_b = matrix_b_text.split('\n')

        A = np.matrix([[float(x) for x in row.split()] for row in rows_a])
        B = np.matrix([[float(x) for x in row.split()] for row in rows_b]).T
        error = float(self.error_input.text())

        result = solution.iterative_method(A, B, error)
        self.result_output.setPlainText(f"Решение: {result}")

    def calculate_determinant(self):
        matrix_a_text = self.matrix_a_input.toPlainText()
        matrix_a_text = matrix_a_text.replace('[', '').replace(']', '').replace(',', '')
        rows_a = matrix_a_text.split('\n')

        matrix_b_text = self.matrix_b_input.toPlainText()
        matrix_b_text = matrix_b_text.replace('[', '').replace(']', '').replace(',', '')
        rows_b = matrix_b_text.split('\n')

        A = np.matrix([[float(x) for x in row.split()] for row in rows_a])
        B = np.matrix([[float(x) for x in row.split()] for row in rows_b]).T

        det = np.linalg.inv(A) * B
        self.result_output.setPlainText(f"Определитель: {det}")


if __name__ == '__main__':
    app = QApplication(sys.argv)
    window = MainWindow()
    window.show()
    sys.exit(app.exec_())
