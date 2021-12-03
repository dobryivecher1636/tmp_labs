import random
import tracemalloc
import time

n = 1000
array = []
for i in range(n):
    array.append(random.randint(1,3000000))

def bubble_sort(array):
    for i in range(n-1):
        for j in range(n-i-1):
            if array[j] > array[j+1]:
                imd = array[j]
                array[j] = array[j+1]
                array[j+1] = imd

def shaker_sort(array):
    left = 0
    right = len(array) - 1
    while left <= right:
        for i in range(left, right, +1):
            if array[i] > array[i + 1]:
                array[i], array[i + 1] = array[i + 1], array[i]
        right -= 1
        for i in range(right, left, -1):
            if array[i - 1] > array[i]:
                array[i], array[i - 1] = array[i - 1], array[i]
        left += 1

def insertion_sort(array):
    for i in range(1, len(array)):
        key = array[i]
        j = i-1
        while j >=0 and key < array[j] :
            array[j+1] = array[j]
            j -= 1
        array[j+1] = key

def selection_sort(array):
        for i in range(0, len(array) - 1):
            s = i
            for j in range(i + 1, len(array)):
                if array[j] < array[s]:
                    s = j
            array[i], array[s] = array[s], array[i]

functions = [bubble_sort, shaker_sort, insertion_sort, selection_sort]
names = ['Сортировка пузырьком', 'Шейкерная сортировка', 'Сортировка вставками', 'Сортировка выбором']

for i in range(len(functions)):
    start = time.perf_counter()
    start_memory = tracemalloc.start()
    functions[i](array)
    stop = time.perf_counter()
    _time = stop - start
    memory = tracemalloc.get_traced_memory()
    tracemalloc.stop()
    print(names[i])
    print(f'Время: {_time:0.4f} секунд')
    print(f'Текущий размер блоков памяти: {memory[0]}\nПиковый размер блоков памяти: {memory[1]}\nРасход памяти: {memory[1]-memory[0]}\n')

