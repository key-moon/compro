// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2241/judge/5238652/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

using P = pair<int, int>;

struct game {
  map<int, P> pos;
  vector<int> colcnt;
  vector<int> rowcnt;
  int n;
  int diag1;
  int diag2;
  int win;
  game(int n, int u) : colcnt(n), rowcnt(n), diag1(0), diag2(0), n(n), win(n == 1 && 1 < u ? 100 : u) {}
  void add(int i, int j, int val) {
    pos[val] = make_pair(i, j);
  }
  bool open(int val) {
    if (!pos.count(val)) return false;
    var i = pos[val].first;
    var j = pos[val].second;
    if (i == j) {
      diag1++;
      if (diag1 == n) win--;
    }
    if (i + j == n - 1) {
      diag2++;
      if (diag2 == n) win--;
    }
    rowcnt[i]++;
    if (rowcnt[i] == n) win--;
    colcnt[j]++;
    if (colcnt[j] == n) win--;
    return win <= 0;
  }
};

int main() {
  int n, u, v, m;
  cin >> n >> u >> v >> m;
  game usa(n, u);
  game neko(n, v);
  var read = [](game& g, int n) {
    for (int i = 0; i < n; i++) {
      for (int j = 0; j < n; j++) {
        int val;
        cin >> val;
        g.add(i, j, val);
      }
    }
  };
  read(usa, n);
  read(neko, n);
  for (int i = 0; i < m; i++) {
    int val;
    cin >> val;
    var usaRes = usa.open(val);
    var nekoRes = neko.open(val);
    if (usaRes && nekoRes) break;
    if (usaRes) {
      cout << "USAGI" << endl;
      return 0;
    }
    if (nekoRes) {
      cout << "NEKO" << endl;
      return 0;
    }
  }
  cout << "DRAW" << endl;
}

