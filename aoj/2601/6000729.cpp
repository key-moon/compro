// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2601/judge/6000729/C++17
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
  int n;
  cin >> n;
  vector<int> is_exit(n, 0);
  vector<int> close_at(n, INT_MAX / 2);
  vector<int> in_until(n, 0);
  for (int i = 0; i < n; i++) {
    int a;
    cin >> a;
    if (a == 0) {
      is_exit[i] = true;
    }
    if (a < 0) {
      close_at[i] = abs(a);
    }
    if (a > 0) {
      in_until[i] = a;
    }
  }
  vector<int> max_person(n, 0);
  var solve = [&](int begin, int end, int dir) {
    int current_max = 0;
    for (int i = begin; i != end; i += dir) {
      if (is_exit[i]) current_max = INT_MAX / 2;
      current_max--; chmax(current_max, 0);
      chmin(current_max, close_at[i]);
      chmax(max_person[i], min(in_until[i], current_max));
    }
  };
  solve(0, n, 1);
  solve(n - 1, -1, -1);
  var res = accumulate(max_person.begin(), max_person.end(), 0);
  cout << res << endl;
}
