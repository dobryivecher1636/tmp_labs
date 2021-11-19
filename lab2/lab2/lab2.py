import random
import string
import hashlib
import tree
import time

def generate_string(l = 24): #функция генерирования случайной строки
    gen_string = ''.join(random.choice(string.ascii_letters + string.digits + string.punctuation) for i in range(l))
    return gen_string

def generate_hash(str): #функция генерирования хэша строки
    hash = (int(hashlib.md5(str.encode('utf-8')).hexdigest(), 16)%10**8)
    return hash

def search_in_file(hashes_to_find): #функция поиска непосредсвенно в файле
    file = open('printedtree.txt').readlines()
    for i in hashes_to_find:
        for _string in file:
            if str(i) in _string:
                break

def search_in_tree(tree, hashes_to_find): #функция поиска по дереву
    for i in hashes_to_find:
        tree.search(tree.get_root, i)

t = tree.Tree()
hashes = []
hashes_to_find = []
with open('printedtree.txt', 'w') as file:
    for i in range(10000): #я сгенерировал 10 000 случайных строк, потому что генерирование 1 000 000 строк занимает слишком много времени (надеюсь, вы не против)
        s =  generate_string()
        h = generate_hash(s)
        t.add(h, i)
        hashes.append(h)
        file.write(s + " : " + str(h) + '\n')
    for i in range(1000):
        hashes_to_find.append(random.choice(hashes))
        
start = time.perf_counter()
search_in_file(hashes_to_find)
stop = time.perf_counter()
_time = stop - start
print(f'Поиск хэшей из файла занял {_time:0.4f} секунд.\n')

start = time.perf_counter()
search_in_tree(t, hashes_to_find)
stop = time.perf_counter()
_time = stop - start
print(f'Поиск хэшей из дерева занял {_time:0.4f} секунд.\n')
