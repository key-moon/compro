// detail: https://atcoder.jp/contests/tenka1-2014-quala/submissions/26670971
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  string s;
  cin >> s;
  s += "----------";

  vector<tuple<int, int, ll>> thrown_queue{};
  vector<pair<int, int>> wait_queue{};

  ll res = 0;
  int stock = 5;
  ll combo = 0;
  int wait_until = -1;
  int time = 0;

  for (var&& c : s) {
    vector<tuple<int, int, ll>> new_thrown_queue{};
    vector<pair<int, int>> new_wait_queue{};
    for (var&& [t, cnt, dmg] : thrown_queue) {
      if (t <= time) {
        res += dmg;
        combo++;
        new_wait_queue.emplace_back(t + 5, cnt);
      }
      else {
        new_thrown_queue.emplace_back(t, cnt, dmg);
      }
    }
    for (var&& [t, cnt] : wait_queue) {
      if (t <= time) {
        stock += cnt;
      }
      else {
        new_wait_queue.emplace_back(t, cnt);
      }
    }
    
    if (c != '-' && wait_until <= time) {
      int need_stock = c == 'N' ? 1 : 3;
      int basedmg = c == 'N' ? 1 : 5;
      int wait = c == 'N' ? 1 : 3;
      ll dmg = basedmg * (10 + combo / 10);

      if (need_stock <= stock) {
        stock -= need_stock;
        new_thrown_queue.emplace_back(time + wait + 1, need_stock, dmg);
        wait_until = time + wait;
      }
    }

    thrown_queue = move(new_thrown_queue);
    wait_queue = move(new_wait_queue);
    time++;
  }

  cout << res << endl;
}


