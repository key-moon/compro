// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2200/judge/4945075/C++17
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template< typename T1, typename T2 >
inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template< typename T1, typename T2 >
inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

int main(){
  //船がどこにあるか
  //船をそれぞれn通り動かして、そこから陸路でえい
  int n, m;
  cin >> n >> m;
  if (n == 0) return 0;
  vector<vector<int>> lcost(n, vector<int>(n, INT32_MAX / 8));
  vector<vector<int>> scost(n, vector<int>(n, INT32_MAX / 8));
  for (int i = 0; i < m; i++){
    int x, y, t;
    char kind;
    cin >> x >> y >> t >> kind;
    x--, y--;
    var& cost = (kind == 'L' ? lcost : scost);
    chmin(cost[x][y], t);
    chmin(cost[y][x], t);
  }
  for (int i = 0; i < n; i++) lcost[i][i] = scost[i][i] = 0;
  for (int i = 0; i < n; i++){
    for (int j = 0; j < n; j++){
      for (int k = 0; k < n; k++){
        chmin(lcost[j][k], lcost[j][i] + lcost[i][k]);
        chmin(scost[j][k], scost[j][i] + scost[i][k]);
      }
    }
  }
  vector<ll> costs(n, INT64_MAX / 8);
  int q;
  cin >> q;
  int last;
  cin >> last; last--;
  costs[last] = 0;
  for (int i = 1; i < q; i++){
    vector<ll> ncosts(n, INT64_MAX / 8);
    int next;
    cin >> next; next--;
    for (int i = 0; i < n; i++){
      ncosts[i] = costs[i] + lcost[last][next];
    }
    for (int curship = 0; curship < n; curship++){    
      int toship = lcost[last][curship];
      for (int nextship = 0; nextship < n; nextship++){
        int sea = scost[curship][nextship];
        int land = lcost[nextship][next];
        chmin(ncosts[nextship], costs[curship] + toship + sea + land);
      }
    }
    costs = move(ncosts);
    last = next;
  }
  ll res = INT64_MAX;
  for (int i = 0; i < n; i++){
    chmin(res, costs[i]);
  }
  cout << res << endl;
  main();
}

