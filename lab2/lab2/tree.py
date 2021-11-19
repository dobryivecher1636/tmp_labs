class Node():
    def __init__(self, value = None, num = None, left = None, right = None):
        self.value = value #значение корня узла
        self.left = left #левый потомок
        self.right = right #правый потомок
        self.num = num #номер строки

    def __str__(self):
      return str(self.value)

class Tree():
    def __init__(self):
        self.root = None

    def add(self, value, num):
      if self.root is None:
          self.root = Node(value, num)
      else:
          self.__add(value, num, self.root)

    def __add(self, value, num, node):
      if value < node.value:
          if node.left is not None:
              self.__add(value, num, node.left)
          else:
              node.left = Node(value, num)
      else:
          if node.right is not None:
              self.__add(value, num, node.right)
          else:
              node.right = Node(value, num)

    @property
    def get_root(self):
        return self.root

    def search(self, node, value):
        if node.value == value:
            return node.num
        else:
            if value > node.value:
                return self.search(node.right, value)
            return self.search(node.left, value)