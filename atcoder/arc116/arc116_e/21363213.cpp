// detail: https://atcoder.jp/contests/arc116/submissions/21363213
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }


vector<vector<int>> g;

int arm = 0;
int cnt = 0;

int DFS(int node, int par, bool& still_safe) {
  int max_spare = -1;
  int max_dist = 0;
  for (var&& adj : g[node]) {
    if (adj == par) continue;
    bool flag;
    var child_res = DFS(adj, node, flag);
    if (flag) chmax(max_spare, child_res);
    else chmax(max_dist, child_res);
  }
  if (max_spare < max_dist) {
    still_safe = false;
    if (max_dist == arm) {
      cnt++;
      still_safe = true;
      return arm - 1;
    }
    return max_dist + 1;
  }
  else {
    still_safe = true;
    /*if (max_spare == 0) {
      still_safe = false;
      return -1;
    }*/
    return max_spare - 1;
  }
}

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  int n, k;
  cin >> n >> k;

  g = vector<vector<int>>(n);
  for (int i = 0; i < n - 1; i++) {
    int s, t;
    cin >> s >> t;
    s--; t--;
    g[s].emplace_back(t);
    g[t].emplace_back(s);
  }

  int leaf = -1;
  for (int i = 0; i < n; i++) {
    if (g[i].size() == 1) {
      leaf = i;
      break;
    }
  }

  int valid = n;
  int invalid = 0;
  while (valid - invalid > 1) {
    var mid = (valid + invalid) / 2;
    arm = mid;
    cnt = 0;
    bool safe;
    DFS(leaf, -1, safe);
    if (!safe) cnt++;
    if (cnt <= k) valid = mid;
    else invalid = mid;
  }
  cout << valid << endl;
}
