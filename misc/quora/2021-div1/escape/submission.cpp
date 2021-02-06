#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) {if(a > b) a = b;}
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) {if(a < b) a = b;}

using namespace std;

int main() {
  int n, m, k;
  cin >> n >> m >> k;
  vector<vector<int>> grid(n, vector<int>(n, 0));
  int sy, sx;
  int gy, gx;
  for (int i = 0; i < n; i++){
    for (int j = 0; j < m; j++){
      char c;
      cin >> c;
      if (c == 'S') { sy = i; sx = j; }
      if (c == 'E') { gy = i; gx = j; }
      if (c == '#') { grid[i][j] = -1; }
    }
  }
  using P = pair<int, int>;
  using PP = pair<int, P>;
  priority_queue<PP> pqueue{};
  for (int i = 0; i < k; i++){
    int r, c, d;
    cin >> r >> c >> d;
    r--; c--;
    pqueue.emplace(PP(d, P(r, c)));
  }
  while (!pqueue.empty()){
    var [d, pos] = pqueue.top(); pqueue.pop();
    var [y, x] = pos;
    if (grid[y][x] == -1) continue;
    grid[y][x] = -1;
    if (d == 0) continue;
    pqueue.emplace(PP(d - 1, P(y - 1, x)));
    pqueue.emplace(PP(d - 1, P(y + 1, x)));
    pqueue.emplace(PP(d - 1, P(y, x - 1)));
    pqueue.emplace(PP(d - 1, P(y, x + 1)));
  }
  queue<PP> q{};
  q.emplace(PP(1, P(sy, sx)));
  while (!q.empty()){
    var [d, pos] = q.front(); q.pop();
    var [y, x] = pos;
    if (grid[y][x] != 0) continue;
    grid[y][x] = d;
    q.emplace(PP(d + 1, P(y - 1, x)));
    q.emplace(PP(d + 1, P(y + 1, x)));
    q.emplace(PP(d + 1, P(y, x - 1)));
    q.emplace(PP(d + 1, P(y, x + 1)));
  }

  if (grid[gy][gx] <= 0){
    cout << "IMPOSSIBLE" << endl;
    return 0;
  }
  cout << grid[gy][gx] - 1 << endl;
}
