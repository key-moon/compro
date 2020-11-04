// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1145/judge/4969404/C++17
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template< typename T1, typename T2 >
inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template< typename T1, typename T2 >
inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

typedef string::const_iterator State;

State stateend;
char res = '0';
int target;

ll chara(State& state, ll cnt);
ll term(State& state, ll cnt);
ll expression(State& state, ll cnt);
ll factor(State& state, ll cnt);

//A
ll chara(State& state, ll cnt){
  assert(isalpha(*state));
  if (cnt == 0) res = *state;
  state++;
  return 1;
}

//3(ABC),3A
ll term(State& state, ll cnt){
  ll total = 0;
  if (!isdigit(*state)){
    total += factor(state, cnt);
  }
  else{
    int rep = 0;
    while (isdigit(*state)){
      rep = rep * 10 + (*state - '0');
      state++;
    }
    var prev = state;
    ll factorcnt = factor(state, cnt);
    if (0 <= cnt && cnt < rep * factorcnt && res == '0')
      factor(prev, cnt % factorcnt);
    cnt -= rep * factorcnt;
    total += rep * factorcnt;
  }
  return total; 
}

// 1A2B3(CD)
ll expression(State& state, ll cnt){
  ll total = 0;
  while (state != stateend && *state != ')'){
    ll termcnt = term(state, cnt);
    total += termcnt;
    cnt -= termcnt;
  }
  return total;
}

// (ABC),A
ll factor(State& state, ll cnt){
  ll total = 0;
  if (*state == '('){
    state++;
    total += expression(state, cnt);
    assert(*state == ')');
    state++;
  }
  else{
    total += chara(state, cnt);
  }
  return total;
}

signed main() {
  cin.tie(0);
  ios::sync_with_stdio(0);
  string s;
  ll cnt;
  cin >> s >> cnt;
  if (s == "0") return 0;
  res = '0';
  State state = s.begin();
  stateend = s.end();
  expression(state, cnt);
  cout << res << endl;
  main();
  return 0;
}

