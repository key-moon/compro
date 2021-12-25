# detail: https://atcoder.jp/contests/xmascon21/submissions/28101840
#   0 1 2
# 3       4
# 
# 5       6
#   7 8 9

fnxt = [
  [
    [], # 0
    [], # 1
    [], # 2
    [("DB", 5, "DB")], # 3
    [], # 4
    [("EB", 5, "B")], # 5
    [], # 6
    [("B", 5, "B")], # 7
    [("A", 9, "A")], # 8
    [("E", 5, "")], # 9
  ],
  [
    [], # 0
    [], # 1
    [], # 2
    [("DC", 5, "DC"), ("DE", 8, "D")], # 3
    [], # 4
    [("EC", 5, "C"), ("EE", 8, "")], # 5
    [], # 6
    [("C", 5, "C"), ("E", 8, "")], # 7
    [], # 8
    [], # 9
  ]
]

bnxt = [
  [
    [("E", 4, "")], # 0
    [("B", 0, "B")], # 1
    [("C", 4, "C")], # 2
    [], # 3
    [("EC", 4, "C")], # 4
    [], # 5
    [("DC", 4, "DC")], # 6
    [], # 7
    [], # 8
    [], # 9
  ],
  [
    [], # 0
    [], # 1
    [("E", 1, ""), ("A", 4, "A")], # 2
    [], # 3
    [("EE", 1, ""), ("EA", 4, "A")], # 4
    [], # 5
    [("DE", 1, "D"), ("DA", 4, "DA")], # 6
    [], # 7
    [], # 8
    [], # 9
  ]
]

from heapq import heappop, heappush
import pickle

i = 0

q = [((0, 0), (3, 6, "",  ""))]

prev_conn = {}
prev_conn[q[0][1]] = (None, ("", ""))

while True:
  _, elem = heappop(q)
  fwd, bck, fsuf, bsuf = elem

  assert(len(fsuf) == 0 or len(bsuf) == 0)
  
  if fwd == 5 and bck == 4 and len(fsuf) == 0 and len(bsuf) == 0:
    res = "D"
    while elem is not None:
      elem, (f_actual, b_actual) = prev_conn[elem]
      res = f_actual + res + b_actual[::-1]
    print(res)
    exit(0)

  for box in [0, 1]:
    for f_label, f_nxt, f_actual in fnxt[box][fwd]:
      fsuf_nxt = fsuf + f_actual
      for b_label, b_nxt, b_actual in bnxt[box][bck]:
        bsuf_nxt = bsuf + b_actual
        suflen = min(len(fsuf_nxt), len(bsuf_nxt))
        if fsuf_nxt[:suflen] != bsuf_nxt[:suflen]: continue
        nxt = (f_nxt, b_nxt, fsuf_nxt[suflen:], bsuf_nxt[suflen:])
        if nxt in prev_conn: continue
        prev_conn[nxt] = (elem, (f_label, b_label))
        remlen = max(len(fsuf_nxt), len(bsuf_nxt)) - suflen
        heappush(q, ((remlen, i), nxt))
        i += 1
